namespace Application.Common.Pagination;

public sealed class Paginate<T>
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }

    public int Index { get; set; } // Hangi Sayfa

    public int Size { get; set; } // Kaç Data Var

    public long Count { get; set; } // Toplam Kayıt Sayısı

    public int Pages { get; set; } // Toplam Kaç Sayfa Var

    public IList<T> Items { get; set; } // Data

    public bool HasPrevious => Index > 0; // Önceki Sayfa

    public bool HasNext => Index + 1 < Pages; // Sonraki Sayfa 
}