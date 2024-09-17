#region usings

using MedicalInfo.Domain.Models;
using MedicalInfo.Infrastructure.Exceptions.Sorting;

#endregion

namespace MedicalInfo.Infrastructure.Sorting;

public class DoctorSortingHelper : ISortingHelper<Doctor>
{
    public IQueryable<Doctor> Sort(IQueryable<Doctor> source, string sortField, bool ascending)
    {
        if (Enum.TryParse(sortField, true, out DoctorSort sortOption))
        {
            return sortOption switch
            {
                DoctorSort.FullName => ascending
                    ? source.OrderBy(d => d.FullName)
                    : source.OrderByDescending(d => d.FullName),
                DoctorSort.Room => ascending
                    ? source.OrderBy(d => d.Room.Number)
                    : source.OrderByDescending(p => p.Room.Number),
                DoctorSort.Specialization => ascending
                    ? source.OrderBy(d => d.Specialization)
                    : source.OrderByDescending(d => d.Specialization),
                DoctorSort.AreaNumber => ascending
                    ? source.OrderBy(d => d.Area.Number)
                    : source.OrderByDescending(d => d.Area.Number),
                _ => throw new ArgumentOutOfRangeException(nameof(sortField))
            };
        }

        throw new NotValidSortFieldException(sortField);
    }
}

public enum DoctorSort
{
    FullName,
    Room,
    Specialization,
    AreaNumber
}