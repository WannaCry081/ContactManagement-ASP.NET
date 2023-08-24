using backend.Entities;

namespace backend.Repositories.ContactLogRepository
{
    /// <summary>
    /// 
    /// </summary> <summary>
    /// 
    /// </summary>
    public interface IContactLogRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactLog"></param>
        /// <returns></returns>
        Task AddContactLog(ContactLog contactLog);
    }
}