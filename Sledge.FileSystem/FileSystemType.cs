﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sledge.FileSystem
{
    /// <summary>
    /// If you really need to know the underlying implementation of a file system, this is the enum that exposes it.
    /// </summary>
    public enum FileSystemType
    {
        /// <summary>
        /// The native Windows file system
        /// </summary>
        Native,

        /// <summary>
        /// A compressed ZIP file
        /// </summary>
        Zip,

        /// <summary>
        /// A Steam GCF file
        /// </summary>
        Gcf,

        /// <summary>
        /// A GoldSource WAD texture file
        /// </summary>
        Wad,

        /// <summary>
        /// A WON GoldSource PAK container file
        /// </summary>
        Pak,

        /// <summary>
        /// A Valve VPK file
        /// </summary>
        Vpk,

        /// <summary>
        /// A non-standard file system implementation
        /// </summary>
        Custom,

        /// <summary>
        /// A combination of multiple file systems
        /// </summary>
        Composite
    }
}