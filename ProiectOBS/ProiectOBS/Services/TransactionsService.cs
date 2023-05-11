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

        public TransactionsService(DepositRepository depositRepository,
                                   WithdrawalRepository withdrawalRepository,
                                   TransferRepository transferRepository,
                                   ClientRepository clientRepository)
        {
            _depositRepository = depositRepository;
            _withdrawalRepository = withdrawalRepository;
            _transferRepository = transferRepository;
            _clientRepository = clientRepository;
        }

        public void AddDeposit(int clientId, int amount)
        {
            var deposit = new Deposit { Id = clientId, Amount = amount, Date = DateTime.Now };
            _depositRepository.Add(deposit);
        }

        public void AddWithdrawal(int clientId, string bank, int amount)
        {
            var withdrawal = new Withdrawal { Id = clientId, Bank = bank, Amount = amount, Date = DateTime.Now };
            _withdrawalRepository.Add(withdrawal);
        }

        public void AddTransfer(int clientId, int recipient, int iban, int amount)
        {
            var transfer = new Transfer { Id = clientId, ClientId1 = recipient, IBAN = iban, Amount = amount, Date = DateTime.Now };
            _transferRepository.Add(transfer);
        }

        public int GetAccountBalance(int clientId)
        {
            var deposits = _depositRepository.GetDepositsByClientId(clientId);
            var withdrawals = _withdrawalRepository.GetWithdrawalsByClientId(clientId);
            var transfers = _transferRepository.GetTransfersByClientId(clientId);

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
                if (transfer.Id == clientId)
                {
                    balance -= transfer.Amount;
                }
                else if (transfer.ClientId1 == clientId)
                {
                    balance += transfer.Amount;
                }
            }

            return (int)balance;
        }
    }
}