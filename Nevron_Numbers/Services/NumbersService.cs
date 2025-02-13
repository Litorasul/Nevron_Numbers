using Nevron_Numbers.Data;

namespace Nevron_Numbers.Services
{
    public class NumbersService : INumbersService
    {
        private readonly DistributedCasheStorage _casheStorage;
        private List<int> _numbers;

        public NumbersService(DistributedCasheStorage casheStorage)
        {
            _casheStorage = casheStorage;
            _numbers = new List<int>();
        }

        public async Task<List<int>> GetList()
        {
            return _numbers.Count > 0 ? _numbers : await _casheStorage.GetAsync<List<int>>(ConstantVariables.NumbersSessionKey);
        }

        public async Task AddNumberToStorage(int number)
        {
            _numbers.Add(number);
            await _casheStorage.SetAsync(ConstantVariables.NumbersSessionKey, _numbers);
        }
        public int GetNumber()
        {
            return new Model().Number;
        }

        public async Task<int> SumNumbers()
        {
            var sum = _numbers.Sum();
            await _casheStorage.SetAsync(ConstantVariables.SumSessionKey, sum);
            return sum;
        }

        public async Task<int> GetSum()
        {
            return await _casheStorage.GetAsync<int>(ConstantVariables.SumSessionKey);
        }

        public void ClearNumbers()
        {
            _casheStorage.Remove(ConstantVariables.NumbersSessionKey);
            _casheStorage.Remove(ConstantVariables.SumSessionKey);
            _numbers = new List<int>();
        }
    }
}
