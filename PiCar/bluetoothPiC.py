import pygame
import bluetooth

SCREENWIDTH = 800
SCREENHEIGHT = 480

class bluetoothPiC:
    green = (0, 255, 0)
    blue = (0, 0, 128)

    def __init__(self, sizeH, sizeW):
        self.sizeH = sizeH
        self.sizeW = sizeW

    def printSearchDevice(self, screen, posH, posW, width, height):
        font = pygame.font.Font('Resources/fonts/OpenSans-Regular.ttf', 10)
        text = font.render('GeeksForGeeks\n\ntravaillll', True, self.green, self.blue)
        textRect = text.get_rect()
        textRect.center = (posW, posH)
        screen.blit(text, textRect)
"""
nearby_devices = bluetooth.discover_devices(lookup_names=True)
print("found %d devices" % len(nearby_devices))

for addr, name in nearby_devices:
    print("  %s - %s" % (addr, name))
"""
