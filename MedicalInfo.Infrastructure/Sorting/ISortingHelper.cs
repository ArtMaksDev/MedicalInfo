namespace MedicalInfo.Infrastructure.Sorting;

public interface ISortingHelper<T>
{
    public IQueryable<T> Sort(IQueryable<T> source, string sortField, bool ascending);
}