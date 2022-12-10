using System;
public class Chicken : Bird
{
	public Chicken()
    {
        throw new NotSupportedException();
    }

    public Chicken(int WeightInOunces) : base()
	{
        base.WeightInOunces = WeightInOunces;
    }

    public override void RemoveBonesAndAdjustWeight()
    {
        if (this.HasBones)
        {
            this.WeightInOunces -= (int)((float)this.WeightInOunces * .32);
            this.HasBones = false;
        }
    }

    public override int GetCalories()
    {
        return this.WeightInOunces * 68;
    }
}

