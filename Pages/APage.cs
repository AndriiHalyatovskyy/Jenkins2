namespace Jenkins2.Pages
{
	public abstract class APage<T>
	{
		protected Pages page;
		protected T selectors;

		public T Selectors
		{
			get { return selectors; }
		}

		protected APage(Pages p, T t)
		{
			page = p;
			selectors = t;
		}
	}
}
