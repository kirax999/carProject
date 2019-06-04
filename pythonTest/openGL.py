import sys
from OpenGL.GL import *
from OpenGL.GLUT import *

def main():
    # Initialize OpenGL
    glutInit(sys.argv)
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB)

    # Configure the display output
    glutGameModeString("800x480:32@60")

    # The application will enter fullscreen
    glutEnterGameMode()

    # Setup callbacks for keyboard and display
    glutKeyboardFunc(keyboard)
    glutDisplayFunc(display)

    # Enters the GLUT event processing loop
    glutMainLoop()

def keyboard(key, x, y):
    ch = key.decode("utf-8")

    if ch == chr(27):
        sys.exit()
    if ch == 'q':
        print('Good bye!')
    sys.exit()

def display():
    glClear(GL_COLOR_BUFFER_BIT)

    # Draw a green line
    glBegin(GL_LINES)
    glColor3f(0.0,100.0,0.0)
    glVertex2f(0, 1)
    glVertex2f(0, -1)
    glVertex2f(1, 0)
    glVertex2f(-1, 0)
    glEnd()

    glutSwapBuffers()

if __name__ == "__main__":
    main()
