﻿namespace SignalRWebUI.Dtos.TestimonialDtos
{
	public class GetTestimonialDtos
	{
		public int TestimonialID { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }
		public string Comment { get; set; }
		public string ImageUrl { get; set; }
		public bool Status { get; set; }
	}
}