﻿namespace StockportGovUK.NetStandard.Gateways.Models.Verint.Eforms
{
    public interface IBaseEform
    {
        /// <summary>
        /// Eforms are instantiated at run time, so must have a parameterless constructor
        /// This intertface requires a method to populate themselves with data from a Case object
        /// </summary>
        /// <param name="crmCase">The case to populate the eform from</param>
        void Populate(Case crmCase);

        /// <summary>
        /// Iterface requiring class to validate itself
        /// </summary>
        /// <returns></returns>
        void Validate();
    }
}
