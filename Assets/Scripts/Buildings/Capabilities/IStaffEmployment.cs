namespace Assets.Scripts.Buildings.Capabilities {
    /// <summary>
    /// Represents the capability to employ staff and require a minimum number of employees to operate properly
    /// </summary>
    interface IStaffEmployment {
        /// <summary>
        /// Current number of employees
        /// </summary>
        int CurrentStaff { get; }

        /// <summary>
        /// Maximum number of employees
        /// </summary>
        int MaxStaff { get; }

        /// <summary>
        /// Minimum number of employees
        /// </summary>
        int MinStaff { get; }


    }
}