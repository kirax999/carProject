import pygame
import WindowManagerPiC
from pygame.locals import *

#Initialisation de la bibliothèque Pygame
pygame.init()

windowManager = WindowManagerPiC.WindowManagerPiC()

windowManager.loopMain()

"""
font = pygame.font.Font('Resources/fonts/OpenSans-Regular.ttf', 10)
text = font.render('GeeksForGeeks', True, green, blue)
textRect = text.get_rect()
textRect.center = (SCREENWIDTH//2, SCREENHEIGHT//2)
"""
