//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18047
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemoteCamera {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        private Gadgeteer.Modules.IngenuityMicro.RfPipe rfPipe;
        
        private Gadgeteer.Modules.GHIElectronics.UsbClientDP usbClientDP;
        
        private Gadgeteer.Modules.GHIElectronics.Joystick joystick;
        
        private Gadgeteer.Modules.GHIElectronics.Display_T35 display_T35;
        
        private Gadgeteer.Modules.GHIElectronics.Button button;
        
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZSpider();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.usbClientDP = new GTM.GHIElectronics.UsbClientDP(1);
            this.button = new GTM.GHIElectronics.Button(6);
            this.rfPipe = new GTM.IngenuityMicro.RfPipe(8);
            this.joystick = new GTM.GHIElectronics.Joystick(10);
            this.display_T35 = new GTM.GHIElectronics.Display_T35(14, 13, 12, Socket.Unused);
        }
    }
}
