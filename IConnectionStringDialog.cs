namespace SQLt
{
    internal interface IConnectionStringDialog
    {
        void SaveOptions();

        void LoadOptions();

        string ConnectionString();
    }
}