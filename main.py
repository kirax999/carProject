import gobject
import phony
"""import phony.base.ipc"""
from phony.base.ipc import *
from phony.audio.alsa import *
from phony.bluetooth.adapters import *
from phony.bluetooth.profiles.handsfree import *

class ExampleHeadsetService:
    _hs = None
    _call_in_progress = False

    def device_connected(self):
        print 'Device connected!'

    def incoming_call(self, call):
        print 'Incoming call: %s' % call
        if self._call_in_progress:
            self._hs.deflect_call_to_voicemail()

    def call_began(self, call):
        print 'Call began: %s' % call
        self._call_in_progress = True

    def call_ended(self, call):
        print 'Call ended: %s' % call
        self._call_in_progress = False

    def start(self):
        bus = phony.base.ipc.BusProvider()
        with phony.bluetooth.adapters.Bluez5(bus) as adapter, \
                phony.bluetooth.profiles.handsfree.Ofono(bus) as hfp, \
                phony.audio.alsa.Alsa(1) as audio, \
                phony.headset.HandsFreeHeadset(bus, adapter, hfp, audio) as hs:
            hs.on_device_connected(self.device_connected)
            hs.on_incoming_call(self.incoming_call)
            hs.on_call_began(self.call_began)
            hs.on_call_ended(self.call_ended)

            hs.start('MyBluetoothHeadset', pincode='1234')
            hs.enable_pairability(timeout=30)

            self._hs = hs

            gobject.MainLoop()

    def voice_dial(self):
        self._hs.initiate_call()

    def dial_number(self, phone_number):
        self._hs.dial(phone_number)


base = ExampleHeadsetService()
ExampleHeadsetService.start(base)
"""
import ip
import cv2
from Tkinter import *

#Makeing Windows
window = Tk()

# interface racine
champ_label = Label(window, text="Citroen C3 PiProject")
addr_ip = Label(window, text=ip.get_ip_address("wlan0"))
window.attributes('-fullscreen', True)
bouton_quitter = Button(window, text="Exit", command=window.quit())

#Add button
bouton_quitter.pack()
champ_label.pack()
addr_ip.pack()

#start window loop
window.mainloop()
"""
