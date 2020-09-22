using Context.Mangers;

namespace App
{
    internal interface IAppManager
    {
        ContextManagers ContextManagers { get; }

        void Initialization();
    }
}