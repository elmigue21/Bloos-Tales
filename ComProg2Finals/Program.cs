using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ComProg2Finals
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            initCustomFont();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }

        public static FontFamily CustomFont;

        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        public static void initCustomFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.PressStart2P_Regular.Length;
            byte[] fontData = Properties.Resources.PressStart2P_Regular;
            System.IntPtr dataPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontLength);
            System.Runtime.InteropServices.Marshal.Copy(fontData,0,dataPtr,fontLength);
            pfc.AddMemoryFont(dataPtr, fontLength);

            uint temp = 0;

            AddFontMemResourceEx(dataPtr, (uint)fontLength, IntPtr.Zero, ref temp);

            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(dataPtr);

            CustomFont = (pfc.Families[0]);
        }
    }
}
