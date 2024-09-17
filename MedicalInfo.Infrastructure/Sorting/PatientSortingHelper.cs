#region usings

using MedicalInfo.Domain.Models;
using MedicalInfo.Infrastructure.Exceptions.Sorting;

#endregion

namespace MedicalInfo.Infrastructure.Sorting;

public class PatientSortingHelper : ISortingHelper<Patient>
{
    public IQueryable<Patient> Sort(IQueryable<Patient> source, string sortField, bool ascending = true)
    {
        if (Enum.TryParse(sortField, true, out PatientSort sortOption))
        {
            return sortOption switch
            {
                PatientSort.FirstName => ascending
                    ? source.OrderBy(p => p.FirstName)
                    : source.OrderByDescending(p => p.FirstName),
                PatientSort.MiddleName => ascending
                    ? source.OrderBy(p => p.MiddleName)
                    : source.OrderByDescending(p => p.MiddleName),
                PatientSort.LastName => ascending
                    ? source.OrderBy(p => p.LastName)
                    : source.OrderByDescending(p => p.LastName),
                PatientSort.Address => ascending
                    ? source.OrderBy(p => p.Address)
                    : source.OrderByDescending(p => p.Address),
                PatientSort.BirthDate => ascending
                    ? source.OrderBy(p => p.BirthDate)
                    : source.OrderByDescending(p => p.BirthDate),
                PatientSort.Gender => ascending
                    ? source.OrderBy(p => p.Gender)
                    : source.OrderByDescending(p => p.Gender),
                PatientSort.AreaNumber => ascending
                    ? source.OrderBy(p => p.Area.Number)
                    : source.OrderByDescending(p => p.Area.Number),
                _ => throw new ArgumentOutOfRangeException(nameof(sortField))
            };
        }

        throw new NotValidSortFieldException(sortField);
    }
}

public enum PatientSort
{
    FirstName,
    MiddleName,
    LastName,
    Address,
    BirthDate,
    Gender,
    AreaNumber
}