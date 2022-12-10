using System;
public class Duck : Bird
{
  
	public Duck()
    {
        throw new NotSupportedException();
    }

    public Duck(int WeightInOunces) : base()
	{
        base.WeightInOunces = WeightInOunces;
    }

    public override void RemoveBonesAndAdjustWeight()
    {
        if (this.HasBones)
        {
            this.WeightInOunces -= (int)((float)this.WeightInOunces * .28);
            this.HasBones = false;
        }
    }

    public override int GetCalories()
    {
        return this.WeightInOunces * 96;
    }
}

