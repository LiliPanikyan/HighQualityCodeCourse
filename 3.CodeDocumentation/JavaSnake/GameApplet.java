import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 * @author SoftUni
 * This class runs our game in a Web browser,
 * containing init() method intended for Applet initialization.
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Game game;
	MovingButton IH;
	
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		IH = new MovingButton(game);
	}
	
	public void paint(Graphics g){
		this.setSize(new Dimension(800, 650));
	}

}

