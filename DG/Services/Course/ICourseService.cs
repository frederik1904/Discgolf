using DG.Data.Model;

namespace DG.Services;

public interface ICourseService
{
    /// <summary>
    /// Fetches pageSize of elements from the database with a given offset
    /// </summary>
    /// <param name="pageSize">The number of items to fetch, by default 20</param>
    /// <param name="offset">The elements to skip, by default 0</param>
    /// <returns>A list of courses with a maximum of the pageSize of elements</returns>
    public Task<List<Course>> GetCourses(int offset = 0, int pageSize = 20);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="holes"></param>
    /// <returns></returns>
    public Task<Course> CreateCourse(string name, int holes);
}