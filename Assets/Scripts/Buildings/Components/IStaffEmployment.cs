namespace Assets.Scripts.Buildings.Components {
    /// <summary>
    /// Represents the capability to employ staff and require a minimum number of employees to operate properly
    /// </summary>
    public interface IStaffEmployment {
        /// <summary>
        /// Maximum number of employees
        /// </summary>
        int MaxStaff { get; }

        /// <summary>
        /// Minimum number of employees
        /// </summary>
        int MinStaff { get; }

        /// <summary>
        /// Current number of employees
        /// </summary>
        int Staff { get; set; }

        /// <returns>True if Staf >= MinStaff, otherwise false</returns>
        bool IsEnoughStaff();
    }
}