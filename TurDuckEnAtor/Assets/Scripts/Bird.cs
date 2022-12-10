using System;
public class Bird
{
	public bool HasBones { get; protected set; }
	public int WeightInOunces { get; protected set; }

	public Bird()
	{
		this.HasBones = true;
	}

    public Bird(int weightInOunces)
    {
        throw new NotImplementedException();
    }

	public bool Debone()
    {
		if (this.HasBones)
		{
            RemoveBonesAndAdjustWeight();

            return true;
		}
		else return false;
    }

	public virtual void RemoveBonesAndAdjustWeight()
    {
        throw new NotImplementedException();
    }

	public virtual int GetCalories()
    {
		throw new NotImplementedException();
    }
}

