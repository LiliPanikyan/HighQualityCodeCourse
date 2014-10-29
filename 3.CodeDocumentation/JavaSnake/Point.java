import java.awt.Color;
import java.awt.Graphics;

/**
 * @author SoftInu
 * This class create points that we will use to create
 * the  objects Snake and Apple, as well as make them movable.
 */
public class Point {
	private int pointX, pointY;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.pointX, p.pointY);
	}
	
	public Point(int x, int y){
		this.pointX = x;
		this.pointY = y;
	}	
		
	public int pointX() {
		return pointX;
	}
	
	public void setPointX(int x) {
		this.pointX = x;
	}
	
	public int pointY() {
		return pointY;
	}
	
	public void setPointY(int y) {
		this.pointY = y;
	}
	
	public void drawSnake(Graphics graphicsKind, Color collorKind) {
		graphicsKind.setColor(Color.BLACK);
		graphicsKind.fillRect(pointX, pointY, WIDTH, HEIGHT);
		graphicsKind.setColor(collorKind);
		graphicsKind.fillRect(pointX+1, pointY+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + pointX + ",y=" + pointY + "]";
	}
	
	public boolean equals(Object possition) {
        if (possition instanceof Point) {
            Point point = (Point)possition;
            return (pointX == point.pointX) && (pointY == point.pointY);
        }
        return false;
    }
}
