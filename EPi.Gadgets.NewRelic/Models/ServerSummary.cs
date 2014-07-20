// Copyright© 2014 Jeroen Stemerdink. All Rights Reserved.
// 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

namespace EPi.Gadgets.NewRelic.Models
{
    /// <summary>
    /// Class Summary.
    /// </summary>
    public class ServerSummary
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the cpu.
        /// </summary>
        /// <value>The cpu.</value>
        public double Cpu { get; set; }

        /// <summary>
        /// Gets or sets the cpu stolen.
        /// </summary>
        /// <value>The cpu stolen.</value>
        public double CpuStolen { get; set; }

        /// <summary>
        /// Gets or sets the disk io.
        /// </summary>
        /// <value>The disk io.</value>
        public double DiskIo { get; set; }

        /// <summary>
        /// Gets or sets the fullest disk.
        /// </summary>
        /// <value>The fullest disk.</value>
        public int FullestDisk { get; set; }

        /// <summary>
        /// Gets or sets the fullest disk free.
        /// </summary>
        /// <value>The fullest disk free.</value>
        public long FullestDiskFree { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the memory.
        /// </summary>
        /// <value>The memory.</value>
        public double Memory { get; set; }

        /// <summary>
        /// Gets or sets the memory total.
        /// </summary>
        /// <value>The memory total.</value>
        public long MemoryTotal { get; set; }

        /// <summary>
        /// Gets or sets the memory used.
        /// </summary>
        /// <value>The memory used.</value>
        public long MemoryUsed { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>The name of the server.</value>
        public string ServerName { get; set; }

        #endregion
    }
}