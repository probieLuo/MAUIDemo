using CocQuery.Models.Coc;

namespace CocQuery.Services.Coc
{
    public class QueryResult<T> where T : class
    {
        public T Items { get; set; } = default!;

        public Paging Paging { get; set; } = default!;

        /// <summary>
        /// Allow explicit conversion from <see cref="QueryResult{T}"/> to T. The reason this is explicit
        /// is that <see cref="Paging"/> information is lost during the conversion.
        /// </summary>
        public static explicit operator T(QueryResult<T> queryResult) => queryResult.Items;
    }
}
