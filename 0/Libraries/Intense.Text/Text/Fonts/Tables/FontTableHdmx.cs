﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intense.Text.Fonts.Tables
{
    /// <summary>
    /// Stores integer advance widths scaled to particular pixel sizes.
    /// </summary>
    public class FontTableHdmx
        : FontTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FontTableHdmx"/>.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="record"></param>
        internal FontTableHdmx(Stream stream, FontTableRecord record)
            : base(stream, record)
        {
            var buffer = ReadTable();

            // TODO: implement
        }
    }
}
