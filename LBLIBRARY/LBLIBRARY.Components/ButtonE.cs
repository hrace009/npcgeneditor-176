using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LBLIBRARY.Components;

public class ButtonE : Button
{
	public enum ButtonsShapes
	{
		RoundRect,
		Circle
	}

	private Color clr1;

	private Color clr2;

	private Color color1 = Color.DodgerBlue;

	private Color color2 = Color.MidnightBlue;

	private Color m_hovercolor1 = Color.Turquoise;

	private Color m_hovercolor2 = Color.DarkSlateGray;

	private int color1Transparent = 250;

	private int color2Transparent = 250;

	private Color clickcolor1 = Color.Yellow;

	private Color clickcolor2 = Color.Red;

	private int angle = 90;

	private int textX = 100;

	private int textY = 25;

	private string text = "";

	public Color buttonborder = Color.FromArgb(220, 220, 220);

	public bool showButtonText = true;

	public int borderWidth = 2;

	public Color borderColor = Color.Transparent;

	private ButtonsShapes buttonShape;

	private Bitmap im;

	private Point imagepos;

	public bool ImToHeight;

	public bool hb;

	public ButtonsShapes ButtonShape
	{
		get
		{
			return buttonShape;
		}
		set
		{
			buttonShape = value;
			Invalidate();
		}
	}

	public string ButtonText
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
			Invalidate();
		}
	}

	public int BorderWidth
	{
		get
		{
			return borderWidth;
		}
		set
		{
			borderWidth = value;
			Invalidate();
		}
	}

	[Category("Image")]
	public new Bitmap Image
	{
		get
		{
			return im;
		}
		set
		{
			im = value;
		}
	}

	[Category("Image")]
	public Point Image_Location
	{
		get
		{
			return imagepos;
		}
		set
		{
			imagepos = value;
			Invalidate();
		}
	}

	[Category("Image")]
	public bool ImageToHeight
	{
		get
		{
			return ImToHeight;
		}
		set
		{
			ImToHeight = value;
			Invalidate();
		}
	}

	[Category("BackColor")]
	public Color BorderColor
	{
		get
		{
			return borderColor;
		}
		set
		{
			borderColor = value;
			if (borderColor == Color.Transparent)
			{
				buttonborder = Color.FromArgb(220, 220, 220);
			}
			else
			{
				SetBorderColor(borderColor);
			}
		}
	}

	[Category("BackColor")]
	public Color StartColor
	{
		get
		{
			return color1;
		}
		set
		{
			color1 = value;
			Invalidate();
		}
	}

	[Category("BackColor")]
	public Color EndColor
	{
		get
		{
			return color2;
		}
		set
		{
			color2 = value;
			Invalidate();
		}
	}

	public Color MouseHoverColor1
	{
		get
		{
			return m_hovercolor1;
		}
		set
		{
			m_hovercolor1 = value;
			Invalidate();
		}
	}

	public Color MouseHoverColor2
	{
		get
		{
			return m_hovercolor2;
		}
		set
		{
			m_hovercolor2 = value;
			Invalidate();
		}
	}

	public Color MouseClickColor1
	{
		get
		{
			return clickcolor1;
		}
		set
		{
			clickcolor1 = value;
			Invalidate();
		}
	}

	public Color MouseClickColor2
	{
		get
		{
			return clickcolor2;
		}
		set
		{
			clickcolor2 = value;
			Invalidate();
		}
	}

	public int Transparent1
	{
		get
		{
			return color1Transparent;
		}
		set
		{
			color1Transparent = value;
			if (color1Transparent > 255)
			{
				color1Transparent = 255;
				Invalidate();
			}
			else
			{
				Invalidate();
			}
		}
	}

	public int Transparent2
	{
		get
		{
			return color2Transparent;
		}
		set
		{
			color2Transparent = value;
			if (color2Transparent > 255)
			{
				color2Transparent = 255;
				Invalidate();
			}
			else
			{
				Invalidate();
			}
		}
	}

	public int GradientAngle
	{
		get
		{
			return angle;
		}
		set
		{
			angle = value;
			Invalidate();
		}
	}

	public int TextLocation_X
	{
		get
		{
			return textX;
		}
		set
		{
			textX = value;
			Invalidate();
		}
	}

	public int TextLocation_Y
	{
		get
		{
			return textY;
		}
		set
		{
			textY = value;
			Invalidate();
		}
	}

	public bool ShowButtontext
	{
		get
		{
			return showButtonText;
		}
		set
		{
			showButtonText = value;
			Invalidate();
		}
	}

	public bool HasBorder
	{
		get
		{
			return hb;
		}
		set
		{
			hb = value;
		}
	}

	private void SetBorderColor(Color bdrColor)
	{
		int num = bdrColor.R - 40;
		int num2 = bdrColor.G - 40;
		int num3 = bdrColor.B - 40;
		if (num < 0)
		{
			num = 0;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num3 < 0)
		{
			num3 = 0;
		}
		buttonborder = Color.FromArgb(num, num2, num3);
	}

	public ButtonE()
	{
		base.Size = new Size(100, 40);
		BackColor = Color.Transparent;
		base.FlatStyle = FlatStyle.Flat;
		base.FlatAppearance.BorderSize = 0;
		base.FlatAppearance.MouseOverBackColor = Color.Transparent;
		base.FlatAppearance.MouseDownBackColor = Color.Transparent;
		text = Text;
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		clr1 = color1;
		clr2 = color2;
		color1 = m_hovercolor1;
		color2 = m_hovercolor2;
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
		color1 = clr1;
		color2 = clr2;
		SetBorderColor(borderColor);
	}

	protected override void OnMouseDown(MouseEventArgs mevent)
	{
		base.OnMouseDown(mevent);
		color1 = clickcolor1;
		color2 = clickcolor2;
		buttonborder = borderColor;
		SetBorderColor(borderColor);
		Invalidate();
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		OnMouseLeave(mevent);
		color1 = clr1;
		color2 = clr2;
		SetBorderColor(borderColor);
		Invalidate();
	}

	protected override void OnLostFocus(EventArgs e)
	{
		base.OnLostFocus(e);
		color1 = clr1;
		color2 = clr2;
		Invalidate();
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		textX = base.Width / 3 - 1;
		textY = base.Height / 3 + 5;
	}

	private void DrawCircularButton(Graphics g)
	{
		Color color = Color.FromArgb(color1Transparent, color1);
		Color color2 = Color.FromArgb(color2Transparent, this.color2);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, angle);
		g.FillEllipse(brush, 5, 5, base.Width - 10, base.Height - 10);
		if (HasBorder)
		{
			for (int i = 0; i < borderWidth; i++)
			{
				g.DrawEllipse(new Pen(new SolidBrush(buttonborder)), 5 + i, 5, base.Width - 10, base.Height - 10);
			}
		}
		if (showButtonText)
		{
			Point point = new Point(textX, textY);
			SolidBrush brush2 = new SolidBrush(ForeColor);
			g.DrawString(text, Font, brush2, point);
		}
		brush.Dispose();
	}

	private void DrawRoundRectangularButton(Graphics g)
	{
		Color color = Color.FromArgb(color1Transparent, color1);
		Color color2 = Color.FromArgb(color2Transparent, this.color2);
		Brush brush = new LinearGradientBrush(base.ClientRectangle, color, color2, angle);
		Region region = new Region(new Rectangle(5, 5, base.Width, base.Height));
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(5, 5, 40, 40, 180f, 90f);
		graphicsPath.AddLine(25, 5, base.Width - 25, 5);
		graphicsPath.AddArc(base.Width - 45, 5, 40, 40, 270f, 90f);
		graphicsPath.AddLine(base.Width - 5, 25, base.Width - 5, base.Height - 25);
		graphicsPath.AddArc(base.Width - 45, base.Height - 45, 40, 40, 0f, 90f);
		graphicsPath.AddLine(25, base.Height - 5, base.Width - 25, base.Height - 5);
		graphicsPath.AddArc(5, base.Height - 45, 40, 40, 90f, 90f);
		graphicsPath.AddLine(5, 25, 5, base.Height - 25);
		region.Intersect(graphicsPath);
		g.FillRegion(brush, region);
		if (HasBorder)
		{
			for (int i = 0; i < borderWidth; i++)
			{
				g.DrawArc(new Pen(buttonborder), 5 + i, 5 + i, 40, 40, 180, 90);
				g.DrawLine(new Pen(buttonborder), 25, 5 + i, base.Width - 25, 5 + i);
				g.DrawArc(new Pen(buttonborder), base.Width - 45 - i, 5 + i, 40, 40, 270, 90);
				g.DrawLine(new Pen(buttonborder), 5 + i, 25, 5 + i, base.Height - 25);
			}
		}
		if (showButtonText)
		{
			Point point = new Point(textX, textY);
			SolidBrush brush2 = new SolidBrush(ForeColor);
			g.DrawString(text, Font, brush2, point);
		}
		brush.Dispose();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		switch (buttonShape)
		{
		case ButtonsShapes.Circle:
			DrawCircularButton(e.Graphics);
			break;
		case ButtonsShapes.RoundRect:
			DrawRoundRectangularButton(e.Graphics);
			break;
		}
		Bitmap source = im;
		if (ImToHeight)
		{
			source = source.ResizeImage(base.Height, base.Height);
		}
		e.Graphics.DrawImage(source, imagepos);
	}
}
