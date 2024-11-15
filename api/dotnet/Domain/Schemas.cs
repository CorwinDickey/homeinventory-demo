namespace Domain
{
    /// <summary>
    /// Defines the DB schemas for categorizing domain objects
    /// </summary>
    public class Schemas
    {
        /// <summary>
        /// The User schema, for all things primarily related to users
        /// </summary>
        public const string User = "User";

        /// <summary>
        /// The MetaData schema, for all things that have no specific categorization and could be used in multiple places
        /// </summary>
        public const string MetaData = "MetaData";

        /// <summary>
        /// The Inventory schema, used for all things primarily related to inventory items
        /// </summary>
        public const string Inventory = "Inventory";
    }
}
