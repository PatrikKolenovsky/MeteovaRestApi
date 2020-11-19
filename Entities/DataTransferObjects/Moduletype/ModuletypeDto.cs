﻿namespace Entities.DataTransferObjects.Moduletype
{
    public class ModuletypeDto
    {
        public int ModuleTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Maker.MakerDto Maker { get; set; }
    }
}
