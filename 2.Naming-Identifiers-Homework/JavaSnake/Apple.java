import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random appleGeneratorPosition;
	private Point applePosition;
	private Color snakeColor;
	
	public Apple(Snake s) {
		applePosition = createApple(s);
		snakeColor = Color.RED;		
	}
	
	private Point createApple(Snake s) {
		appleGeneratorPosition = new Random();
		int x = appleGeneratorPosition.nextInt(30) * 20; 
		int y = appleGeneratorPosition.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.pointX() || y == snakePoint.pointY()) {
				return createApple(s);				
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
