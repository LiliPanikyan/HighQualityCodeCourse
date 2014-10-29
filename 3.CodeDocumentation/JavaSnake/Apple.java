import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * @author SoftUni
 * This class create the object Apple,
 * containing methods for position and color,
 * and drawing the Apple on the screen.
 */
public class Apple {
	public static Random appleGeneratorPosition;
	private Point applePosition;
	private Color snakeColor;
	
	public Apple(Snake s) {
		applePosition = createApplePosition(s);
		snakeColor = Color.RED;		
	}
	
	/**
	 * Method gives random position on which to plot the Apple,
	 * but different from that of the snake.
	 * @param s
	 * @return
	 */
	private Point createApplePosition(Snake s) {
		appleGeneratorPosition = new Random();
		int x = appleGeneratorPosition.nextInt(30) * 20; 
		int y = appleGeneratorPosition.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.pointX() || y == snakePoint.pointY()) {
				return createApplePosition(s);				
			}
		}
		
		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
		applePosition.drawSnake(g, snakeColor);
	}	
	
	public Point setPosition(){
		return applePosition;
	}
}
