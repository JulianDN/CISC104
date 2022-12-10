using System;

public class TurDuckEn : Bird
{
    private Turkey turkey;
    private Duck duck;
    private Chicken chicken;

    public bool IsPreparedForOven { get; private set; }
    public bool IsCooked { get; private set; }

    public int CookedMinutes { get; private set; }


	public TurDuckEn()
	{
		throw new NotImplementedException();
	}

	public TurDuckEn(Turkey turkey, Duck duck, Chicken chicken)
    {
        if(turkey.HasBones || duck.HasBones || chicken.HasBones)
        {
      
            throw new NotSupportedException();
        }

      
        this.turkey = turkey;
        this.duck = duck;
        this.chicken = chicken;

        base.WeightInOunces = GetTotalWeightInOunces();


        this.IsPreparedForOven = false;

        this.IsCooked = false;
        this.CookedMinutes = 0;
    }

    public override void RemoveBonesAndAdjustWeight()
    {
        throw new NotSupportedException();
    }

    public override int GetCalories()
    {
        return (this.turkey.GetCalories() + this.duck.GetCalories() + this.chicken.GetCalories());
    }

    public void PrepareForOven()
    {
        this.IsPreparedForOven = true;
    }

    public int RequiredMinutesOfCooking()
    {
        return this.GetTotalWeightInOunces();
    }

    public void CookOneMinute()
    {
        if(this.CookedMinutes < this.RequiredMinutesOfCooking())
        {
            this.CookedMinutes++;
        }

        if(this.CookedMinutes >= this.RequiredMinutesOfCooking())
        {
            this.IsCooked = true;
        }
    }

    public int GetTotalWeightInOunces()
    {
        return (this.turkey.WeightInOunces + this.duck.WeightInOunces + this.chicken.WeightInOunces);
    }
}

