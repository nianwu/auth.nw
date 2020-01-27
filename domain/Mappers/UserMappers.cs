using AutoMapper;

namespace domain.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for Users.
    /// </summary>
    public static class UserMappers
    {
        static UserMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Models.User ToModel(this EntityFramework.Storage.Entities.User entity)
        {
            return Mapper.Map<Models.User>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static EntityFramework.Storage.Entities.User ToEntity(this Models.User model)
        {
            return Mapper.Map<EntityFramework.Storage.Entities.User>(model);
        }
    }
}