public class Solution {
		List<IList<int>> results = null;
		int[] data;
		int length = -1;
		public IList<IList<int>> PermuteUnique(int[] nums)
        {
			Array.Sort(nums);
			data = nums;
			results = new List<IList<int>>();
			length = nums.Length;
			List<int> prefix = new List<int>();
			bool[] used = new bool[nums.Length];
			for (int i = 0; i < nums.Length; i++)
			{
				used[i] = false;
			}

			dfs(prefix, used);
			return (IList<IList<int>>) results;
		}


		private void dfs(List<int> prefix, bool[] used)
		{
			if (prefix.Count == length)
			{
				results.Add((IList<int>)prefix);
			}

			for (int i = 0; i < used.Length; i++)
			{
				if (used[i] || ((i > 0) && (data[i] == data[i - 1]) && (used[i - 1] == false)))
					continue;
				//two choices: either skip data[i] or use data[i];
				//dfs(prefix, used); //need to avoid infinite loop

				List<int> newPrefix = new List<int>(prefix);
				newPrefix.Add(data[i]);
				used[i] = true;
				dfs(newPrefix, used);
				used[i] = false;
			}
		}
}