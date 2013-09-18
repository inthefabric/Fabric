using System.Collections.Generic;
using Fabric.Api.Dto.Traversal;
using Fabric.Domain;
using Fabric.Infrastructure;
using Fabric.Infrastructure.Data;
using Fabric.Infrastructure.Weaver;
using Moq;
using NUnit.Framework;

namespace Fabric.Test.FabApiDto {

	/*================================================================================================*/
	[TestFixture]
	public class TFabFactor {


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorFillVertex() {
			const long year = 2013;
			byte? month = 12;
			byte? day = 4;

			var f = new Factor();
			f.Eventor_DateTime = FabricUtil.EventorTimesToLong(year, month, day, null, null, null);

			var ff = new FabFactor(f);
			
			Assert.NotNull(ff.Eventor, "Eventor should be filled.");
			Assert.AreEqual(year, ff.Eventor.Year, "Incorrect Eventor.Year.");
			Assert.AreEqual(month, ff.Eventor.Month, "Incorrect Eventor.Month.");
			Assert.AreEqual(day, ff.Eventor.Day, "Incorrect Eventor.Day.");
			Assert.Null(ff.Eventor.Hour, "Eventor.Hour should be null.");
			Assert.Null(ff.Eventor.Minute, "Eventor.Minute should be null.");
			Assert.Null(ff.Eventor.Second, "Eventor.Second should be null.");
		}
		
		/*--------------------------------------------------------------------------------------------*/
		[Test]
		public void EventorFillData() {
			const long year = 2013;
			byte? month = 12;
			byte? day = 4;
			
			var data = new Dictionary<string, string>();
			data.Add(PropDbName.Factor_FactorId, "1");
			data.Add(PropDbName.Factor_FactorAssertionId, "1");
			data.Add(PropDbName.Factor_IsDefining, "true");
			data.Add(PropDbName.Factor_Created, "1");
			data.Add(PropDbName.Factor_Eventor_DateTime,
				FabricUtil.EventorTimesToLong(year, month, day, null, null, null)+"");

			var mockDto = new Mock<IDataDto>();
			mockDto.SetupGet(x => x.Id).Returns("1");
			mockDto.SetupGet(x => x.Properties).Returns(data);

			var ff = new FabFactor();
			ff.Fill(mockDto.Object);
			
			Assert.NotNull(ff.Eventor, "Eventor should be filled.");
			Assert.AreEqual(year, ff.Eventor.Year, "Incorrect Eventor.Year.");
			Assert.AreEqual(month, ff.Eventor.Month, "Incorrect Eventor.Month.");
			Assert.AreEqual(day, ff.Eventor.Day, "Incorrect Eventor.Day.");
			Assert.Null(ff.Eventor.Hour, "Eventor.Hour should be null.");
			Assert.Null(ff.Eventor.Minute, "Eventor.Minute should be null.");
			Assert.Null(ff.Eventor.Second, "Eventor.Second should be null.");
		}

	}

}