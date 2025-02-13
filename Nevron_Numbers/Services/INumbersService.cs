
namespace Nevron_Numbers.Services
{
    public interface INumbersService
    {
        /// <summary>
        /// Adds a new number to the List in storage.
        /// </summary>
        Task AddNumberToStorage(int number);
        /// <summary>
        /// Gets the current List of numbers from storage.
        /// </summary>
        Task<List<int>> GetList();
        /// <summary>
        /// Gets a new random nuber in range 1 - 1000.
        /// </summary>
        int GetNumber();
        /// <summary>
        /// Sums the current list of numbers.
        /// </summary>
        Task<int> SumNumbers();
        /// <summary>
        /// Gets the current sum of numbers from storage.
        /// </summary>
        Task<int> GetSum();
        /// <summary>
        /// Clears the current List of nubers and Sum.
        /// </summary>
        void ClearNumbers();
    }
}