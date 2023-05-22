using ProiectOBS.Models;
using ProiectOBS.Repositories;

namespace ProiectOBS.Services
{
    public class TransactionsService
    {
        private readonly DepositRepository _depositRepository;
        private readonly WithdrawalRepository _withdrawalRepository;
        private readonly TransferRepository _transferRepository;
        private readonly ClientRepository _clientRepository;
        private readonly TransactionsRepository _transactionsRepository;

        public TransactionsService(DepositRepository depositRepository,
                                   WithdrawalRepository withdrawalRepository,
                                   TransferRepository transferRepository,
                                   ClientRepository clientRepository,
                                   TransactionsRepository transactionsRepository)
        {
            _depositRepository = depositRepository;
            _withdrawalRepository = withdrawalRepository;
            _transferRepository = transferRepository;
            _clientRepository = clientRepository;
            _transactionsRepository = transactionsRepository;
        }

        public void AddDeposit(int clientId, int amount)
        {
            var deposit = new Deposit { Amount = amount};
            _depositRepository.Add(deposit);

            var transaction = new Transactions {ClientId = clientId, DepositId = deposit.Id };
            _transactionsRepository.AddTransaction(transaction);
        }

        public void AddWithdrawal(int clientId, string bank, int amount)
        {
            var withdrawal = new Withdrawal { Bank = bank, Amount = amount, Date = DateTime.Now };
            _withdrawalRepository.Add(withdrawal);

            var transaction = new Transactions { ClientId = clientId, WithdrawalId = withdrawal.Id };
            _transactionsRepository.AddTransaction(transaction);
        }

        public void AddTransfer(int clientId, int recipient, int iban, int amount)
        {
            var transfer = new Transfer { ClientId1 = recipient, IBAN = iban, Amount = amount, Date = DateTime.Now };
            _transferRepository.Add(transfer);

            var transaction = new Transactions { ClientId = clientId, TransferId = transfer.Id };
            _transactionsRepository.AddTransaction(transaction);
        }

        public int GetAccountBalance(int clientId)
        {
            clientId = 1;
            var deposits = _transactionsRepository.GetDepositsByClientId(clientId);
            var withdrawals = _transactionsRepository.GetWithdrawalsByClientId(clientId);
            var transfers = _transactionsRepository.GetTransfersByClientId(clientId);

            int? balance = 0;

            foreach (var deposit in deposits)
            {
                balance += deposit.Amount;
            }

            foreach (var withdrawal in withdrawals)
            {
                balance -= withdrawal.Amount;
            }

            foreach (var transfer in transfers)
            {
                if (transfer.ClientId1 == clientId)
                {
                    balance += transfer.Amount;
                }
                else
                {
                    balance -= transfer.Amount;
                }
            }

            return (int)balance;
        }
    }
}