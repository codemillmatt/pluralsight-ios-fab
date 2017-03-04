using System;
using UIKit;
using CoreAnimation;
using CoreGraphics;
using Foundation;

namespace FabLib
{
	public class FabButton : UIView
	{
		CAShapeLayer circleLayer;
		CAShapeLayer tintLayer;

		CAShapeLayer downLayer;
		CAShapeLayer crossLayer;

		public event EventHandler<EventArgs> ButtonPressed;


		public FabButton() : base(new CGRect(0, 0, 40, 40))
		{
			Initialize();
		}

		public FabButton(CGRect rect) : base(rect)
		{
			Initialize();
		}

		void Initialize()
		{
			BackgroundColor = UIColor.Clear;
			UserInteractionEnabled = true;
		}

		public override void Draw(CGRect rect)
		{
			// This will always end up 40x40 with the original x,y
			var fabRect = new CGRect(rect.Location, new CGSize(40, 40));
			fabRect = rect;

			base.Draw(fabRect);

			circleLayer = new CAShapeLayer();
			var bp = UIBezierPath.FromOval(fabRect);
			circleLayer.Path = bp.CGPath;
			circleLayer.FillColor = UIColor.FromRGB(230, 248, 37).CGColor;
			Layer.AddSublayer(circleLayer);

			tintLayer = new CAShapeLayer();
			tintLayer.Path = bp.CGPath;
			tintLayer.FillColor = UIColor.FromRGB(168, 181, 27).CGColor;

			// Calculate the X and Y for the cross rectangles
			var xMidPointLow = fabRect.GetMidX() - 2;
			var xMidPointHigh = fabRect.GetMidX() + 2;
			var xPointLow = fabRect.GetMinX() + 8;
			var xPointHigh = fabRect.GetMaxX() - 8;

			var yMidPointLow = fabRect.GetMidY() - 2;
			var yMidPointHigh = fabRect.GetMidY() + 2;
			var yPointLow = fabRect.GetMinY() + 8;
			var yPointHigh = fabRect.GetMaxY() - 8;

			downLayer = new CAShapeLayer();
			var downRect = new CGRect(xMidPointLow, yPointLow, xMidPointHigh - xMidPointLow, yPointHigh - yPointLow);
			var downBp = UIBezierPath.FromRoundedRect(downRect, 2);
			downLayer.Path = downBp.CGPath;
			downLayer.FillColor = UIColor.FromRGB(232, 80, 80).CGColor;
			Layer.AddSublayer(downLayer);

			crossLayer = new CAShapeLayer();
			var crossRect = new CGRect(xPointLow, yMidPointLow, xPointHigh - xPointLow, yMidPointHigh - yMidPointLow);
			var crossBp = UIBezierPath.FromRoundedRect(crossRect, 2);
			crossLayer.Path = crossBp.CGPath;
			crossLayer.FillColor = UIColor.FromRGB(232, 80, 80).CGColor;
			Layer.AddSublayer(crossLayer);
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			Layer.InsertSublayerBelow(tintLayer, downLayer);
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);

			tintLayer.RemoveFromSuperLayer();

			ButtonPressed?.Invoke(this, new EventArgs());
		}
	}
}
