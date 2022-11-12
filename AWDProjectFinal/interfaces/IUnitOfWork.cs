namespace AWDProjectFinal.interfaces
{
    public interface IUnitOfWork
    {
        IApartment Apartment { get; }

        IOwner Owner { get; }

        void Save();
    }
}
