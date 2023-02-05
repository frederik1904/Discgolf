using DG.Data;
using DG.Data.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DG.Services;

public class CourseService : ICourseService
{
    private readonly ApplicationDbContext _context;

    public CourseService(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    public Task<List<Course>> GetCourses(int offset = 0, int pageSize = 20)
    {
        return _context.Courses
            .OrderByDescending(course => course.Created)
            .Skip(offset)
            .Take(pageSize)
            .ToListAsync();
    }

    public Task<Course> CreateCourse(string name, int holes)
    {
        var course = new Course()
        {
            Name = name,
            Holes = holes
        };

        _context.Courses.AddAsync(course);
        _context.SaveChangesAsync();
        return Task.FromResult(course);
    }
}