using System;


namespace Emaritna.Bll.ViewModels.Base
{
    public class PagingDataViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 25;


        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;

        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages && TotalPages > 0;
    }
}