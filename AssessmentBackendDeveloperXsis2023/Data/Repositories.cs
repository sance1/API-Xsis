using System;
using AssessmentBackendDeveloperXsis2023.Models;
using AssessmentBackendDeveloperXsis2023.Interface;
using Microsoft.Extensions.Configuration;

namespace AssessmentBackendDeveloperXsis2023.Data
{
    public class Repositories : IRepositories
    {
      
        private readonly DataContext _context;
        public Repositories(DataContext context)
        {
            _context = context;
        }
        public List<Movie> movies()
        {
            try {
                var data = _context.Movies
               .OrderBy(x => x.Id)
               .ToList();
                return data;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message} || {e.InnerException?.Message}");
            }
        }
        public void AddOrUpdateMovie(Movie newMovie)
        {
            try
            {
                var data = _context.Movies
                    .FirstOrDefault(x => x.Id == newMovie.Id) ?? new Movie();

                if (data.Id == 0) _context.Movies.Add(newMovie);
                data.Title = newMovie.Title;
                data.Description = newMovie.Description;
                data.Rating = newMovie.Rating;
                data.Image = newMovie.Image;
                data.Created_At = newMovie.Created_At;
                data.Updated_At = newMovie.Updated_At;
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message} || {e.InnerException?.Message}");
            }
        }

        public void DeleteMovie(int Id)
        {
            try
            {
                var data = _context.Movies
                    .FirstOrDefault(x => x.Id == Id) ?? new Movie();

                if (data.Id != 0) _context.Movies.Remove(data);
                _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message} || {e.InnerException?.Message}");
            }
        }


    }
}

