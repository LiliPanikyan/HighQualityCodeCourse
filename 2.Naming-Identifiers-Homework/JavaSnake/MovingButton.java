import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class MovingButton implements KeyListener{
	
	public MovingButton(Game game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int playerMove = e.getKeyCode();
		
		if (playerMove == KeyEvent.VK_W || playerMove == KeyEvent.VK_UP) {
			if(Game.snake.getVelocityY() != 20){
				Game.snake.setVelocityX(0);
				Game.snake.setVelocityY(-20);
			}
		}
		
		if (playerMove == KeyEvent.VK_S || playerMove == KeyEvent.VK_DOWN) {
			if(Game.snake.getVelocityY() != -20){
				Game.snake.setVelocityX(0);
				Game.snake.setVelocityY(20);
			}
		}
		
		if (playerMove == KeyEvent.VK_D || playerMove == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelocityX() != -20){
			Game.snake.setVelocityX(20);
			Game.snake.setVelocityY(0);
			}
		}
		
		if (playerMove == KeyEvent.VK_A || playerMove == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelocityX() != 20){
				Game.snake.setVelocityX(-20);
				Game.snake.setVelocityY(0);
			}
		}
		
		//Other controls
		if (playerMove == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}

}
