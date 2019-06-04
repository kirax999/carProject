import pygame
import camera
from pygame.locals import *

#Window Manager
"""

fullScreen: type 1 = Camera

"""

SCREENWIDTH = 800
SCREENHEIGHT = 480

GREEN = (  0, 255,   0)

#Création de la fenêtre
fenetre = pygame.display.set_mode((SCREENWIDTH, SCREENHEIGHT), pygame.FULLSCREEN)

class WindowManager:
    def __init__(self):
        self.cameraView = camera.camera(0, SCREENHEIGHT, SCREENWIDTH)
        self.sizeWin = True

    def loopMain(self):
        continuer = 1
        while continuer:
            if self.sizeWin:
                self.printElement(1, 3)
            else:
                self.fullScreen(1)
            for event in pygame.event.get():   #On parcours la liste de tous les événements reçus
                if event.type == KEYDOWN and event.key == K_SPACE:     #Si un de ces événements est de type QUIT
                    continuer = 0      #On arrête la boucle
                if event.type == KEYDOWN and event.key == K_1:
                    self.sizeWin = not self.sizeWin
            pygame.display.update()

    def drawLine(self):
        pygame.draw.line(fenetre, GREEN, [0, SCREENHEIGHT//2], [SCREENWIDTH,SCREENHEIGHT//2], 1)
        pygame.draw.line(fenetre, GREEN, [SCREENWIDTH//2, 0], [SCREENWIDTH//2,SCREENHEIGHT], 1)

    def fullScreen(self, type):
        fenetre.fill([0,0,0])
        if type == 1:
            self.cameraView.refreshFrame(fenetre, 0, 0, SCREENWIDTH//2, SCREENHEIGHT//2)

    def printElement(self, type, position):
        lentWidth = (SCREENWIDTH//2 + 1)
        lentHeight = (SCREENHEIGHT//2 + 1)
        sizeWidth = (SCREENWIDTH//2) - 1
        sizeHeight = (SCREENHEIGHT//2) - 1
        if position == 1 or position == 2:
            lentHeight = 0
        if position == 3 or position == 4:
            lentHeight = (SCREENHEIGHT//2) + 1
        if position == 1 or position == 3:
            lentWidth = 0

        fenetre.fill([0,0,0])
        self.drawLine()
        self.cameraView.refreshFrame(fenetre, lentHeight, lentWidth, sizeWidth, sizeHeight)
