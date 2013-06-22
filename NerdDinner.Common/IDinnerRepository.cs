using System;
using System.Collections.Generic;

namespace NerdDinner
{
	public interface IDinnerRepository
	{
		List<Dinner> FindUpcomingDinners();
	}
}
