using System;
public class Turkey : Bird
{

	public Turkey()
    {
        throw new NotSupportedException();
    }

    public Turkey(int WeightInOunces) : base()
	{
        base.WeightInOunces = WeightInOunces;
	}

    public override void RemoveBonesAndAdjustWeight()
    {
        if (this.HasBones)
        {
            this.WeightInOunces -= (int)((float)this.WeightInOunces * .27);
            this.HasBones = false;
        }
    }

    public override int GetCalories()
    {
        return this.WeightInOunces * 54;
    }
}

