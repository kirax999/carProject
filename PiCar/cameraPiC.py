import pygame
from pygame.locals import *
import cv2
import numpy as np
import sys

class cameraPiC:
    def __init__(self, fdCamera, sizeH, sizeW):
        self.Wcamera = cv2.VideoCapture(0)
        self.sizeH = sizeH
        self.sizeW = sizeW

    def refreshFrame(self, screen, posH, posW, width, height):
        try:
            ret, frame = self.Wcamera.read()
            sizeW = width / self.sizeW
            sizeH = height / self.sizeH
            frame = cv2.resize(frame, None, fx=(sizeW), fy=(sizeH), interpolation=cv2.INTER_AREA)
            frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
            frame = np.rot90(frame)
            tmp = (width - frame.shape[1]) / 4
            frame = pygame.surfarray.make_surface(frame)
            screen.blit(frame, (posW + tmp, posH))
        except:
            pygame.quit()
            cv2.destroyAllWindows()
