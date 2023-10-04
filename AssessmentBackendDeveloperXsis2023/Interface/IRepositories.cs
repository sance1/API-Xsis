using System;
using AssessmentBackendDeveloperXsis2023.Models;

namespace AssessmentBackendDeveloperXsis2023.Interface
{
    public interface IRepositories
    {
        List<Movie> movies();
        void AddOrUpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}

