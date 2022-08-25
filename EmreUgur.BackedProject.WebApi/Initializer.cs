using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Common.Helpers;
using EmreUgur.BackedProject.Common.StringInfos;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.WebApi
{
    public class Initializer
    {
        public static async Task SeedData(IAppUserService appUserService, IAppRoleService appRoleService, IAppUserRoleService appUserRoleService)
        {
            var adminRole = await appRoleService.GetAsync(x => x.Name == RoleInfo.Admin);

            int roleId = 0, userId = 0;

            if (adminRole == null)
            {
                roleId = await appRoleService.AddAsync(new AppRole() { Name = RoleInfo.Admin });
            }

            var adminUser = await appUserService.GetAsync(x => x.Name == RoleInfo.Admin);

            if (adminUser == null)
            {
                AppUser user = new AppUser
                {
                    Name = RoleInfo.Admin,
                    SurName = "Admin",
                    UserName = "admin",
                    Email = "admin@hotmail.com",
                    IsActive = true,
                    Password = PasswordHelper.PasswordEnCrypt("1")
                };

                userId = await appUserService.AddAsync(user);

                AppUserRole appUserRole = new()
                {
                    AppUserId = userId,
                    AppRoleId = roleId
                };

                await appUserRoleService.AddAsync(appUserRole);
            }
        }

        public static async Task SeedData2(IColorService colorService, IVehicleService vehicleService, IWheelService wheelService, IHeadlightService headlightService, ICarService carService, IBusService busService, IBoatService boatService)
        {
            var colors = await colorService.GetAllAsync();

            if (colors == null || colors.Count <= 0)
            {

                #region ColorsAdd
                Color color1 = new Color { Name = "Red" };
                Color color2 = new Color { Name = "Blue" };
                Color color3 = new Color { Name = "Black" };
                Color color4 = new Color { Name = "White" };

                await colorService.AddAsync(color1);
                await colorService.AddAsync(color2);
                await colorService.AddAsync(color3);
                await colorService.AddAsync(color4);
                #endregion

                #region VehiclesAdd
                Vehicle vehicle1 = new Vehicle { ColorId = color1.Id };
                Vehicle vehicle2 = new Vehicle { ColorId = color2.Id };
                Vehicle vehicle3 = new Vehicle { ColorId = color3.Id };
                Vehicle vehicle4 = new Vehicle { ColorId = color4.Id };

                await vehicleService.AddAsync(vehicle1);
                await vehicleService.AddAsync(vehicle2);
                await vehicleService.AddAsync(vehicle3);
                await vehicleService.AddAsync(vehicle4); https://i.ytimg.com/vi/5-hrDo19dIQ/mqdefault.jpg
                #endregion

                #region WheelsAdd
                Wheel wheel1 = new Wheel { Name = "Wheel1" };
                Wheel wheel2 = new Wheel { Name = "Wheel2" };

                await wheelService.AddAsync(wheel1);
                await wheelService.AddAsync(wheel2);
                #endregion

                #region HeadlightsAdd
                Headlight headlight1 = new Headlight { Name = "Headlight1" };
                Headlight headlight2 = new Headlight { Name = "Headlight2" };

                await headlightService.AddAsync(headlight1);
                await headlightService.AddAsync(headlight2);
                #endregion

                #region CarsAdd
                await carService.AddAsync(new Car { WheelId = wheel1.Id, HeadlightId = headlight1.Id, VehicleId = vehicle1.Id, Name = "Car1", ModelYear = 2022 });
                await carService.AddAsync(new Car { WheelId = wheel2.Id, HeadlightId = headlight2.Id, VehicleId = vehicle2.Id, Name = "Car2", ModelYear = 2021 });
                await carService.AddAsync(new Car { WheelId = wheel1.Id, HeadlightId = headlight2.Id, VehicleId = vehicle2.Id, Name = "Car3", ModelYear = 2020 });
                await carService.AddAsync(new Car { WheelId = wheel2.Id, HeadlightId = headlight1.Id, VehicleId = vehicle3.Id, Name = "Car4", ModelYear = 2019 });
                await carService.AddAsync(new Car { WheelId = wheel2.Id, HeadlightId = headlight1.Id, VehicleId = vehicle3.Id, Name = "Car5", ModelYear = 2018 });
                await carService.AddAsync(new Car { WheelId = wheel1.Id, HeadlightId = headlight2.Id, VehicleId = vehicle3.Id, Name = "Car6", ModelYear = 2017 });
                await carService.AddAsync(new Car { WheelId = wheel2.Id, HeadlightId = headlight1.Id, VehicleId = vehicle4.Id, Name = "Car7", ModelYear = 2016 });
                await carService.AddAsync(new Car { WheelId = wheel1.Id, HeadlightId = headlight2.Id, VehicleId = vehicle4.Id, Name = "Car8", ModelYear = 2015 });
                await carService.AddAsync(new Car { WheelId = wheel2.Id, HeadlightId = headlight2.Id, VehicleId = vehicle4.Id, Name = "Car9", ModelYear = 2014 });
                await carService.AddAsync(new Car { WheelId = wheel1.Id, HeadlightId = headlight1.Id, VehicleId = vehicle4.Id, Name = "Car10", ModelYear = 2013 });
                #endregion

                #region BusesAdd
                await busService.AddAsync(new Bus { VehicleId = vehicle1.Id, Name = "Bus1", ModelYear = 2022 });
                await busService.AddAsync(new Bus { VehicleId = vehicle1.Id, Name = "Bus2", ModelYear = 2021 });
                await busService.AddAsync(new Bus { VehicleId = vehicle1.Id, Name = "Bus3", ModelYear = 2020 });
                await busService.AddAsync(new Bus { VehicleId = vehicle3.Id, Name = "Bus4", ModelYear = 2019 });
                #endregion

                #region BoatsAdd
                await boatService.AddAsync(new Boat { VehicleId = vehicle3.Id, Name = "Boat1", ModelYear = 2022 });
                await boatService.AddAsync(new Boat { VehicleId = vehicle4.Id, Name = "Boat2", ModelYear = 2021 });
                await boatService.AddAsync(new Boat { VehicleId = vehicle4.Id, Name = "Boat3", ModelYear = 2020 });
                await boatService.AddAsync(new Boat { VehicleId = vehicle2.Id, Name = "Boat4", ModelYear = 2019 });
                #endregion
            }

        }
    }
}
