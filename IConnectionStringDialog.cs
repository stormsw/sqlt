
namespace SQLt
{
    interface IConnectionStringDialog
    {
        void SaveOptions();
        void LoadOptions();
        string ConnectionString();
    }
}
