import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * @author SoftUni
 * This class, create the object Snake,
 * containing methods for position and color,
 * direction of movement,
 * and drawing the Snake on the screen.
 */
public class Snake{
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100)); 
		snakeBody.add(new Point(280, 100)); 
		snakeBody.add(new Point(260, 100)); 
		snakeBody.add(new Point(240, 100)); 
		snakeBody.add(new Point(220, 100)); 
		snakeBody.add(new Point(200, 100)); 
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void printSnake(Graphics g) {		
		for (Point point : this.snakeBody) {
			point.drawSnake(g, snakeColor);
		}
	}
	
	/**
	 * The method specifies the movement of a snake and
	 * when the snake eats the Apple, and when the snake eats herself.
	 */
	public void tick() {
		Point snakeNewpossition = new Point((snakeBody.get(0).pointX() + velocityX), (snakeBody.get(0).pointY() + velocityY));
		
		if (snakeNewpossition.pointX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (snakeNewpossition.pointX() < 0) {
			Game.gameRunning = false;
		} else if (snakeNewpossition.pointY() < 0) {
			Game.gameRunning = false;
		} else if (snakeNewpossition.pointY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.setPosition().equals(snakeNewpossition)) {
			snakeBody.add(Game.apple.setPosition());
			Game.apple = new Apple(this);
			Game.gamePoints += 50;
		} else if (snakeBody.contains(snakeNewpossition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}
		
		snakeBody.set(0, snakeNewpossition);
	}

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velX) {
		this.velocityX = velX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velY) {
		this.velocityY = velY;
	}
}
