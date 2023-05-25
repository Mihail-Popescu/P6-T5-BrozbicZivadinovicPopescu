using NUnit.Framework;
using ProiectOBS.Data;
using ProiectOBS.Repositories;
using ProiectOBS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UnitTests
{
    public class TransactionsPageTests
    {
        private ProiectOBSDbContext _dbContext;
        private DepositRepository _depositRepository;
        private TransactionsRepository _transactionsRepository;
        private TransactionsService _transactionsService;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            // Create configuration
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Use the configuration to create DbContextOptions
            var options = new DbContextOptionsBuilder<ProiectOBSDbContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options;

            // Create ProiectOBSDbContext instance with DbContextOptions and IConfiguration
            _dbContext = new ProiectOBSDbContext(options, _configuration);

            // Create repositories and service with the context
            _depositRepository = new DepositRepository(_dbContext);
            var withdrawalRepository = new WithdrawalRepository(_dbContext);
            var transferRepository = new TransferRepository(_dbContext);
            var clientRepository = new ClientRepository(_dbContext);
            _transactionsRepository = new TransactionsRepository(_dbContext);

            _transactionsService = new TransactionsService(
                _depositRepository,
                withdrawalRepository,
                transferRepository,
                clientRepository,
                _transactionsRepository
            );
        }

        [SetUp]
        public void InitalTearDown()
        {
            // Clear tables before the first test
            _dbContext.Deposit.RemoveRange(_dbContext.Deposit);
            _dbContext.Withdrawal.RemoveRange(_dbContext.Withdrawal);
            _dbContext.Transfer.RemoveRange(_dbContext.Transfer);
            _dbContext.Transactions.RemoveRange(_dbContext.Transactions);
            _dbContext.SaveChanges();

        }

        [TearDown]
        public void FinalTearDown()
        {
            // Clear tables after each test
            _dbContext.Deposit.RemoveRange(_dbContext.Deposit);
            _dbContext.Withdrawal.RemoveRange(_dbContext.Withdrawal);
            _dbContext.Transfer.RemoveRange(_dbContext.Transfer);
            _dbContext.Transactions.RemoveRange(_dbContext.Transactions);
            _dbContext.SaveChanges();
        }

        [Test] // Add Deposit ~~~
        public void AddDeposit_ValidData_DepositAndTransactionAdded()
        {
            // Arrange
            int clientId = 1;
            int amount = 100;

            // Act
            _transactionsService.AddDeposit(clientId, amount);

            // Assert
            var deposits = _dbContext.Deposit.ToList();
            var transactions = _dbContext.Transactions.ToList();

            Assert.AreEqual(1, deposits.Count());
            Assert.AreEqual(1, transactions.Count());
            Assert.AreEqual(amount, deposits.First().Amount);
            Assert.AreEqual(clientId, transactions.First().ClientId);
            Assert.AreEqual(deposits.First().Id, transactions.First().DepositId);
        }

        [Test] // AddWithdrawal ~~~
        public void AddWithdrawal_ValidData_WithdrawalAndTransactionAdded()
        {
            // Arrange
            int clientId = 1;
            string bank = "Bank ABC";
            int amount = 200;

            // Act
            _transactionsService.AddWithdrawal(clientId, bank, amount);

            // Assert
            var withdrawals = _dbContext.Withdrawal.ToList();
            var transactions = _dbContext.Transactions.ToList();
            
            Assert.AreEqual(1, withdrawals.Count());
            Assert.AreEqual(1, transactions.Count());
            Assert.AreEqual(amount, withdrawals.First().Amount);
            Assert.AreEqual(bank, withdrawals.First().Bank);
            Assert.AreEqual(clientId, transactions.First().ClientId);
            Assert.AreEqual(withdrawals.First().Id, transactions.First().WithdrawalId);
        }

        [Test] // AddTransfer~~~
        public void AddTransfer_ValidData_TransferAndTransactionAdded()
        {
            // Arrange
            int clientId = 1;
            int recipient = 2;
            int iban = 123456789;
            int amount = 500;

            // Act
            _transactionsService.AddTransfer(clientId, recipient, iban, amount);

            // Assert
            var transfers = _dbContext.Transfer.ToList();
            var transactions = _dbContext.Transactions.ToList();

            Assert.AreEqual(1, transfers.Count());
            Assert.AreEqual(1, transactions.Count());
            Assert.AreEqual(amount, transfers.First().Amount);
            Assert.AreEqual(clientId, transactions.First().ClientId);
            Assert.AreEqual(recipient, transfers.First().ClientId1);
            Assert.AreEqual(iban, transfers.First().IBAN);
            Assert.AreEqual(transfers.First().Id, transactions.First().TransferId);
        }

        [Test] // GetAccountBalance ~~~
        public void GetAccountBalance_ValidData_ReturnsCorrectBalance()
        {
            // Arrange
            int clientId = 1;

            // Add deposits
            _transactionsService.AddDeposit(clientId, 100);
            _transactionsService.AddDeposit(clientId, 200);
            _transactionsService.AddDeposit(clientId, 300);

            // Add withdrawals
            _transactionsService.AddWithdrawal(clientId, "Bank A", 100);
            _transactionsService.AddWithdrawal(clientId, "Bank B", 200);

            // Add transfers
            _transactionsService.AddTransfer(clientId, 2, 123456789, 150);
            _transactionsService.AddTransfer(clientId, 2, 123456789, 50);

            // Act
            int balance = _transactionsService.GetAccountBalance(clientId);

            // Assert
            Assert.AreEqual(100, balance);
        }

    }
}
