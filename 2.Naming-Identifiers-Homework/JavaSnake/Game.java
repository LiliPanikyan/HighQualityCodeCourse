import java.awt.Canvas;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
public class Game extends Canvas implements Runnable {
	public static Snake snake;
	public static Apple apple;
	static int gamePoints;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension gameSize = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;
	
	public void paint(Graphics g){
		this.setPreferredSize(gameSize);
		globalGraphics = g.create();
		gamePoints = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
			}
		}
	}
	
	public Game(){	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT+25);
		g.drawRect(0, 0, WIDTH, HEIGHT);
		
		snake.printSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + gamePoints, 10, HEIGHT + 25);		
	}
}

