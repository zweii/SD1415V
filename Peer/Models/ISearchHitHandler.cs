namespace Models
{
    interface ISearchHitHandler
    {
        void Hit(int id, SearchHit sh);
    }
}